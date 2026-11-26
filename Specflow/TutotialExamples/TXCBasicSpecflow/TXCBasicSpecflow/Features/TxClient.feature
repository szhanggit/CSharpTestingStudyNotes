@cleanUpClients
Feature: TxClient
	Simple calculator for adding two numbers

Scenario: Get Client
	Given Environment <Environment> <API_URL>
	And The parameter TenantBasicInfoId '<TenantBasicInfoId>'
	And The parameter TenantName '<TenantName>'
	And The parameter SearchKey '<SearchKey>'
	When I send get client request
	Then The response message is <ResponseMessage>

	Examples:
		| Environment | API_URL				  | TenantBasicInfoId | TenantName | SearchKey | ResponseMessage |
		| staging     | api/Client/GetClients | 9                 | GL         | Katie1    | success         |
		| staging     | api/Client/GetClients | 1                 | Singapore  | Katie2    | success         |


Scenario: Create New Client
	Given Environment <Environment> <API_URL>
	And The parameter TenantBasicInfoId '<TenantBasicInfoId>'
	And The parameter TenantName '<TenantName>'
	And The parameter ClientName '<ClientName>'
	And The parameter InvoiceRegisterNumber '<InvoiceRegisterNumber>'
	And The parameter Status '<Status>'
	And The parameter SecurityAlgorithm '<SecurityAlgorithm>'
	And The parameter SecurityKey '<SecurityKey>'
	And The parameter NeedNotification '<NeedNotification>'
	And The parameter CanIssue '<CanIssue>'
	And The parameter DetailAddressLine '<DetailAddressLine>'
	And The parameter District '<District>'
	And The parameter CityId '<CityId>'
	And The parameter StateOrProvinceId '<StateOrProvinceId>'
	And The parameter Postcode '<Postcode>'
	And The parameter CountryId '<CountryId>'
	And The parameter AddressStatus '<AddressStatus>'
	#OPTIONAL PARAMS
	#And The parameter VoucherIssuerId <VoucherIssuerId>
	#And The parameter InvoiceTitle <InvoiceTitle>
	#And The parameter BusinessTypeId <BusinessTypeId>
	#And The parameter NotiNotificationProviderCodeId <NotiNotificationProviderCodeId>
	#And The parameter LogoMediaId <LogoMediaId>
	#And The parameter BannerMediaId <BannerMediaId>
	#And The parameter EmailHeaderMediaId <EmailHeaderMediaId>
	#And The parameter EmailFooterMediaId <EmailFooterMediaId>
	#And The parameter MandatoryAutoBilling <MandatoryAutoBilling>
	#And The parameter SubURL <SubURL>
	#And The parameter EmailProviderCode <EmailProviderCode>
	#And The parameter EmailSenderName <EmailSenderName>
	#And The parameter EmailSenderAddress <EmailSenderAddress>
	#And The parameter ApplyEmailSubject <ApplyEmailSubject>
	#And The parameter SMSProviderCode <SMSProviderCode>
	#And The parameter SMSSenderName <SMSSenderName>
	#And The parameter SmsEntityId <SmsEntityId>
	#And The parameter SalesEmail <SalesEmail>
	#And The parameter ContactName <ContactName>
	#And The parameter ContactEmail <ContactEmail>
	#And The parameter ContactPhone <ContactPhone>
	#And The parameter Memo <Memo>
	#And The parameter Description <Description>
	#And The parameter Longitude <Longitude>
	#And The parameter Latitude <Latitude>
	When I send create client request
	Then The response message is <ResponseMessage>

	Examples:
		| Environment | API_URL					| TenantBasicInfoId | TenantName | ClientName           | InvoiceRegisterNumber | Status | SecurityAlgorithm | SecurityKey      | NeedNotification | CanIssue | DetailAddressLine | District | CityId | StateOrProvinceId | Postcode | CountryId | AddressStatus | VoucherIssuerId | InvoiceTitle | BusinessTypeId | NotiNotificationProviderCodeId | LogoMediaId | BannerMediaId | EmailHeaderMediaId | EmailFooterMediaId | MandatoryAutoBilling | SubURL | EmailProviderCode | EmailSenderName | EmailSenderAddress | ApplyEmailSubject | SMSProviderCode | SMSSenderName | SmsEntityId | SalesEmail | ContactName | ContactEmail | ContactPhone | Memo | Description | Longitude | Latitude | ResponseMessage |
		| staging     | api/Client/CreateClient | 7                 | TW         | SpecFlowCreateClient | 12345678              | 1      | 1                 | B94C3A096DDEEAF9 | false            | true     | sample            | sample   | 10     | 7                 | sample   | 6         | 0             |                 |              |                |                                |             |               |                    |                    |                      |        |                   |                 |                    |                   |                 |               |             |            |             |              |              |      |             |           |          | success         |