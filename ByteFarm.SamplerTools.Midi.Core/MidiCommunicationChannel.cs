﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Commons.Music.Midi;

namespace ByteFarm.SamplerTools.Midi.Core
{
    public class MidiCommunicationChannel : IDisposable
    {
        /// <summary>
        ///     Do not access directly. Call GetNextTimestamp instead;
        /// </summary>
        private static long _timestamp;

        private readonly ConcurrentDictionary<long, Action<IMidiResponse>> _responseHandlers =
            new ConcurrentDictionary<long, Action<IMidiResponse>>();

        private readonly IMidiInput Input;
        private readonly IMidiOutput Output;

        public EventHandler<MidiResponseReceivedEventArgs> MidiResponse;

        public MidiCommunicationChannel(IMidiInput input, IMidiOutput output)
        {
            Input = input;
            Output = output;

            InputPortDetails = new MidiPortDetails(input.Details);
            OutputPortDetails = new MidiPortDetails(output.Details);

            Input.MessageReceived += Input_MessageReceived;
        }

        public MidiCommunicationChannel(string inputNameOrId, string outputNameOrId) : this(MidiAccessManager.Default,
            inputNameOrId, outputNameOrId)
        {
        }


        private MidiCommunicationChannel(IMidiAccess midiAccess, string inputNameOrId, string outputNameOrId) : this(
            midiAccess.OpenInputAsync(midiAccess.Inputs.First(a => a.Name == inputNameOrId || a.Id == inputNameOrId).Id)
                .Result,
            midiAccess.OpenOutputAsync(midiAccess.Outputs.First(a => a.Name == outputNameOrId || a.Id == outputNameOrId)
                .Id).Result)
        {
        }

        public MidiPortDetails OutputPortDetails { get; }

        public MidiPortDetails InputPortDetails { get; }

        public static List<MidiPortDetails> AvailableMidiInputPorts =>
            MidiAccessManager.Empty.Inputs.Select(a => new MidiPortDetails(a)).ToList();

        public bool Disposed { get; private set; }

        public void Dispose()
        {
            if (!Disposed) Dispose(true);
        }

        private void Input_MessageReceived(object sender, MidiReceivedEventArgs e)
        {
            var response = new MidiResponse(e.Data);
            if (_responseHandlers.TryRemove(e.Timestamp, out var handler)) handler(response);

            MidiResponse?.Invoke(this, new MidiResponseReceivedEventArgs(response));
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
                if (!Disposed)
                {
                    if (Input != null) Input.MessageReceived -= Input_MessageReceived;

                    Input?.Dispose();
                    Output?.Dispose();
                    Disposed = true;
                }
        }

        public long GetNextTimestamp()
        {
            return Interlocked.Increment(ref _timestamp);
        }

        public void SendMidiMessage(IMidiMessage message)
        {
            SendMidiMessage(message, null);
        }

        public void SendMidiMessage(IMidiMessage message, Action<IMidiResponse> responseHandler)
        {
            var ts = GetNextTimestamp();

            if (responseHandler != null) _responseHandlers.TryAdd(ts, responseHandler);

            var bytes = message.FormatToMidiBytes();

            Output.Send(bytes, 0, bytes.Length, ts);
        }

        public class MidiPortDetails
        {
            public MidiPortDetails(IMidiPortDetails midiPortDetails)
            {
                Id = midiPortDetails.Id;
                Manufacturer = midiPortDetails.Manufacturer;
                Name = midiPortDetails.Name;
                Version = midiPortDetails.Version;
            }

            public string Version { get; }

            public string Name { get; }

            public string Manufacturer { get; }

            public string Id { get; }
        }
    }
}