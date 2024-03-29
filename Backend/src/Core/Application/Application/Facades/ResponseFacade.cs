﻿using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Core.Application.Facades
{
    public static class ResponseFacade
    {

        /// <summary>
        /// Build a Response Message Octet Stream Type for file Download 
        /// </summary>
        /// <param name="filePath">A path for the file</param>
        /// <param name="fileName">A name for the file on content disposition </param>
        /// <returns></returns>
        public static  HttpResponseMessage BuildFileResponseMessage(string filePath, string fileName) => BuildFileFromMemoryResponseMessage(new FileStream(filePath, FileMode.Open, FileAccess.Read), fileName);


        public static HttpResponseMessage BuildFileFromMemoryResponseMessage(Stream memoryStream, string fileName, string headerType = "application/octet-stream")
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);

            httpResponseMessage.Content = new StreamContent(memoryStream);
            httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(headerType);
            httpResponseMessage.Content.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
            httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = fileName;

            return httpResponseMessage;
        }


    }
}
