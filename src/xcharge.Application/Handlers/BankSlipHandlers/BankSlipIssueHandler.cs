using MediatR;
using xcharge.Application.CQS.Commands.BankSlipCommand;
using xcharge.Application.DTOs.BankSlip.Requests;
using xcharge.Application.DTOs.BankSlip.Responses;
using xcharge.Application.Interfaces.Mappers;
using xcharge.Application.Interfaces.Services;
using xcharge.Shared.Helpers;
using xcharge.Shared.Settings.HttpClientSettings;

namespace xcharge.Application.Handlers.BankSlipHandlers;

public class BankSlipIssueHandler(IHttpClient httpClient, IBankSlipIssueMapper mapper)
    : IRequestHandler<BankSlipIssueCommand, Result<BankSlipIssueDto>>
{
    private readonly IHttpClient _httpClient = httpClient;
    private readonly IBankSlipIssueMapper _mapper = mapper;

    public async Task<Result<BankSlipIssueDto>> Handle(
        BankSlipIssueCommand command,
        CancellationToken cancellationToken
    )
    {
        var request = this._mapper.Map(command);

        var result = await this._httpClient.CreateClient<BankSlipIssueRequest, BankSlipIssueDto>(
            HttpClientSettingsEnum.BankSlipIssue,
            request
        );

        if (result is null)
        {
            return Result<BankSlipIssueDto>.RequestFailed(
                "Request was failed",
                System.Net.HttpStatusCode.InternalServerError,
                [new Error("failed")]
            );
        }

        return Result<BankSlipIssueDto>.RequestOk(result);
    }
}
