Feature: UpdateTxProductPriceCommand

Scenario: Update Product Price with All Parameters
	Given Environment <Environment> <API_URL>
	And The parameter TenantBasicInfoId '<TenantBasicInfoId>'
	And The parameter TenantName '<TenantName>'
	And The parameter TX2UserName '<TX2UserName>'
	And The parameter ProductId '<ProductId>'
	And The parameter FaceValue '<FaceValue>'
	And The parameter FaceValueWithTax '<FaceValueWithTax>'
	And The parameter SellingPricePrepaid '<SellingPricePrepaid>'
	And The parameter SellingPricePrepaidWithTax '<SellingPricePrepaidWithTax>'
	When I send update product price value request
	Then The response message is <ResponseMessage>

	Examples:
		| Environment | API_URL                      | TenantBasicInfoId | TenantName | TX2UserName | ProductId | FaceValue | FaceValueWithTax | SellingPricePrepaid | SellingPricePrepaidWithTax | ResponseMessage |
		| staging     | api/Product/Price			 | 9                 | GL         | msioson     | 1         | 10        | 10               | 2.345               | 2.345                      | 0000            |