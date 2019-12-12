# Square9.CA.ExchangeRates
Call Assembly to calculate an amount based on real time exchange rate data.  With this tool, customers can work with amount
data that might be in a different currency, say GBP (British Pound), and convert the amount to the US Dollar (USD) equivalent
based on the real time exchange rate, served by an external exchange rate API (in this case, ratesapi.io).  Download the supported version of this assembly here:  http://square9zgm.sftp.wpengine.com/dlls/Square9.CA.ExchangeRates.dll

The example demonstrates both a Call Assembly for GlobalCapture or GlobalAction, and a console application that demonstrates
how to test an assembly without having to setup and wait for workflows to run.  In general, it's a good practice to test your Assembly 
in an actual workflow before deploying to production, but for initial development, the test console is a far more efficient approach.

To use the assembly, 3 process fields are required and should be initialized with data.  The name of the Process Field and its ID are
not relevant to the Assembly, but process fields with the value described below must be present.

# Process Field 1
Amount:877.36
A process field should exist with the literal value "Amount:" followed by the amount to convert.

# Process Field 2
Currency:GBP
A process field should exist with the literal value "Currency:" followed by the currency code to convert from.

# Process Field 3
Converted:
A process field should exist with the literal value "Converted:".  This value will be replaced with the USD equivalent amount.
