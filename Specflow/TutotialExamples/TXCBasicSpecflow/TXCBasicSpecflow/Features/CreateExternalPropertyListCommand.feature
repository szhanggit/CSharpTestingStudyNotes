Feature: CreateExternalPropertyListCommand

Scenario: Update Product External Property Value with All Parameters
	Given Environment <Environment> <API_URL>
	And The parameter TenantBasicInfoId '<TenantBasicInfoId>'
	And The parameter TenantName '<TenantName>'
	And The parameter TX2UserName '<TX2UserName>'
	And The parameter ProductId '<ProductId>'
	And The parameter PropertyName '<PropertyName>'
	And The parameter PropertyValue '<PropertyValue>'
	And The parameter Description '<Description>'
	When I send update product external property value request
	Then The response message is <ResponseMessage>

	Examples:
		| Environment | API_URL                      | TenantBasicInfoId | TenantName | TX2UserName | ProductId | PropertyName | PropertyValue | Description | ResponseMessage |
		| staging     | api/Product/ExternalProperty | 9                 | GL         | msioson     | 1         | SKU          | 1001862       | Update      | success         |