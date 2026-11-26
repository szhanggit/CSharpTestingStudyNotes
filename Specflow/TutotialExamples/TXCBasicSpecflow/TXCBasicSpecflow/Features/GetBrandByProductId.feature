Feature: GetBrandByProductId

Scenario: Get brand by product ID
	Given Environment <Environment> <API_URL>
	And The parameter TenantBasicInfoId '<TenantBasicInfoId>'
	And The parameter TenantName '<TenantName>'
	And The parameter TX2UserName '<TX2UserName>'
	And The parameter ProductId '<ProductId>'
	When I send get brand by product ID request
	Then The response message is <ResponseMessage>

	Examples:
		| Environment | API_URL						| TenantBasicInfoId | TenantName | TX2UserName | ProductId | ResponseMessage |
		| staging     | api/Product/GetProductBrand | 9                 | GL         | msioson     | 1         | success         |