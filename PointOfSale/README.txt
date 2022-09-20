## To test it from a browser, try the links below:

1. http://localhost:65511/api/pointOfSale/StartShopping/
	1.1. Save the PurchaseId to paste it into the scan method (let's say it's 1)
2. http://localhost:65511/api/pointOfSale/Scan/1/C
3. Repeat 2nd step 6 times (total 7 times)
4. http://localhost:65511/api/pointOfSale/GetTotalPrice/1/
