using Microsoft.Azure.KeyVault.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerBI.Services.Key_Vault
{
    public class PrefixKeyVaultSecretManager : IKeyVaultSecretManager
    {
        private readonly IList<string> _prefixes;

        public PrefixKeyVaultSecretManager(string prefix) =>
            _prefixes = new List<string> { $"{prefix}-" };

        public PrefixKeyVaultSecretManager(string[] prefixes) =>
            _prefixes = prefixes.Select(p => $"{p}-").ToArray();

        public PrefixKeyVaultSecretManager(IList<string> prefixes) =>
            _prefixes = prefixes.Select(p => $"{p}-").ToArray();

        public bool Load(SecretItem secret) =>
            _prefixes.Any(p => secret.Identifier.Name.StartsWith(p));

        public string GetKey(SecretBundle secret)
        {
            var prefix = _prefixes.FirstOrDefault(p => secret.SecretIdentifier.Name.StartsWith(p));
            
            string secretName = null;

            if(String.IsNullOrEmpty(prefix))
            {
                secretName = secret.SecretIdentifier.Name.Replace("--", ConfigurationPath.KeyDelimiter);
            }
            else
            {
                secretName = secret.SecretIdentifier.Name.Substring(prefix.Length).Replace("--", ConfigurationPath.KeyDelimiter);
            }

            return secretName;
        }
    }
}
