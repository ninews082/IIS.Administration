﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.


using System.Security.Cryptography.X509Certificates;

namespace Microsoft.IIS.Administration.WebServer.CentralCertificates
{
    sealed class CertificateIdentifier
    {
        private const char DELIMITER = '\n';

        private const uint THUMBPRINT_INDEX = 0;
        private const uint FILE_NAME_INDEX = 1;

        public string Thumbprint { get; private set; }
        public string FileName { get; private set; }

        public string Id { get; private set; }

        private CertificateIdentifier() { }

        public static CertificateIdentifier Parse(string id)
        {
            var info = id.Split(DELIMITER);

            return new CertificateIdentifier() {
                Thumbprint = info[THUMBPRINT_INDEX],
                FileName = info[FILE_NAME_INDEX],
                Id = id
            };
        }

        public CertificateIdentifier(X509Certificate2 cert)
        {
            this.Thumbprint = cert.Thumbprint;
            this.FileName = cert.FriendlyName;

            this.Id = $"{ this.Thumbprint }{ DELIMITER }{ this.FileName }";
        }
    }
}