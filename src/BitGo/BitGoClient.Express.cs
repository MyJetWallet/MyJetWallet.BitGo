﻿using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.BitGo.Models;
using MyJetWallet.BitGo.Models.Enterprise;
using MyJetWallet.BitGo.Models.Express;
using MyJetWallet.BitGo.Models.PendingApproval;
using MyJetWallet.BitGo.Models.Shared;

namespace MyJetWallet.BitGo
{
    public partial class BitGoClient
    {
        public async Task<WebCallResult<PingExpressResult>> PingExpressAsync(CancellationToken cancellationToken = default)
        {
            return await this.GetAsync<PingExpressResult>($"{this.EndpointUrl}/pingexpress", cancellationToken);
        }

        public async Task<WebCallResult<VerifyAddressResult>> VerifyAddressAsync(string coin, string address, CancellationToken cancellationToken = default)
        {
            var request = new
            {
                address
            };

            return await this.PostAsync<VerifyAddressResult>($"{this.EndpointUrl}/{coin}/verifyaddress", request, cancellationToken);
        }

        public async Task<WebCallResult<SendCoinResult>> SendCoinsAsync(
            string coin,
            string walletId,
            SendCoinsRequestData request,
            CancellationToken cancellationToken = default)
        {
            var resp = await this.PostAsync<SendCoinResult>($"{this.EndpointUrl}/{coin}/wallet/{walletId}/sendcoins", request, cancellationToken);

            resp.Data.IsRequireApproval = resp.ResponseStatusCode == HttpStatusCode.Accepted;

            return resp;
        }


        public Task<WebCallResult<SendCoinResult>> SendCoinsAsync(
            string coin, string walletId, string walletPassphrase,
            string sequenceId, string amount, 
            string address, MemoType memo = null, 
            CancellationToken cancellationToken = default)
        {
            var request = new SendCoinsRequestData()
            {
                WalletPassphrase = walletPassphrase,
                Address = address,
                Amount = amount,
                SequenceId = sequenceId,
                Memo = memo
            };

            return SendCoinsAsync(coin, walletId, request, cancellationToken);
        }
    }
}