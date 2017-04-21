﻿using System;
using Newtonsoft.Json;

namespace Mastodon.API
{
    /// <summary>
    /// Attachment.
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md#attachment
    /// </summary>
    public class Attachment
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; }
        [JsonProperty(PropertyName = "url")]
        public Uri Url { get; }
        [JsonProperty(PropertyName = "remote_url")]
        public Uri RemoteUrl { get; }
        [JsonProperty(PropertyName = "preview_url")]
        public Uri PreviewUrl { get; }
        [JsonProperty(PropertyName = "text_url")]
        public Uri TextUrl { get; }

        public Attachment(string id, string type, Uri url, Uri remoteUrl, Uri previewUrl, Uri textUrl)
        {
            Id = id;
            Type = type;
            Url = url;
            RemoteUrl = remoteUrl;
            PreviewUrl = previewUrl;
            TextUrl = textUrl;
        }

        public override string ToString()
        {
            return string.Format("[Attachment: Id={0}, Type={1}, Url={2}, RemoteUrl={3}, PreviewUrl={4}, TextUrl={5}]", Id, Type, Url, RemoteUrl, PreviewUrl, TextUrl);
        }

        public override bool Equals(object obj)
        {
            var o = obj as Attachment;
            if (o == null) return false;
            return Equals(Id, o.Id) &&
                Equals(Type, o.Type) &&
                Equals(Url, o.Url) &&
                Equals(RemoteUrl, o.RemoteUrl) &&
                Equals(PreviewUrl, o.PreviewUrl) &&
                Equals(TextUrl, o.TextUrl);
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode(Id, Type, Url, RemoteUrl, PreviewUrl, TextUrl);
        }
    }
}

