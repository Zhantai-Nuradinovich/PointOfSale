## Steps to test Web API:

- GET http://localhost:65511/api/pointOfSale/Shopping/
	- Save the PurchaseId to paste it into the scan method (let's say it's 1)
- GET http://localhost:65511/api/pointOfSale/Scan/1/C
- Repeat 2nd step as much as you need
- POST http://localhost:65511/api/pointOfSale/TotalPrice/ with the body:

```
{
	"PurchaseId": 1,
	"Prices": [
		{
			"Amount": 1,
			"PriceValue": 0.75,
			"ProductCode": "D"
		},
		{
			"Amount": 1,
			"PriceValue": 1,
			"ProductCode": "C"
		},
		{
			"Amount": 1,
			"PriceValue": 1.25,
			"ProductCode": "A"
		},
		{
			"Amount": 1,
			"PriceValue": 4.25,
			"ProductCode": "B"
		},
		{
			"Amount": 3,
			"PriceValue": 3,
			"ProductCode": "A"
		},
		{
			"Amount": 6,
			"PriceValue": 5,
			"ProductCode": "C"
		},
	]
}
```
