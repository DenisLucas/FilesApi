using System;

namespace File.Util.Helpers
{
    public class UrlHelper
    {
        private readonly string _baseUrl;
        public UrlHelper(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public Uri getUri(string fileId)
        {
            return new Uri(_baseUrl + "/get/api/v1/{id}".Replace("{id}",fileId));

        }
    }
}
