﻿using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FileIO
{
    public class FileDownload
    {
        HttpClient _client;

        public FileDownload(HttpClient client)
        {
            if (client != null)
                _client = client;
            else
                _client = new HttpClient();
        }

        public async Task<string> DownloadFileAsync()
        {

            string url = "https://github.com/Ravindra-a/largefile/blob/master/README.md"; //Replace this with any URL
            using (HttpResponseMessage response = await _client.GetAsync(url)) // Should mock GetAsync for unit tests
            {
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(result))
                {
                    throw new Exception("Empty file content");
                }

                // Now reverse this string - In enterprise appication this will be some business logic
                StringBuilder reverseString = new StringBuilder();
                for (int i= result.Length - 1; i>=0;i--)
                {
                    reverseString.Append(result[i]);
                }
                return reverseString.ToString();
            }
        }
    }
}
