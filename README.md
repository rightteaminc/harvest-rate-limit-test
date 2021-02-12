# Harvest Rate Limit Test

This repository contains a small console app that illustrating that the Harvest API appears to be rate limiting to 100 requests per 15 seconds per IP address, and not per account token. 

Documentation for Harvest Rate Limits is [here](https://help.getharvest.com/api-v2/introduction/overview/general/#rate-limiting).

## Test Process

1. Initialize 2 separate Harvest accounts (unique account id and token)
2. Make a rapid number of requests to each account
3. Record any responses that result in a failure

Observe that if the app is run with 50 requests, there will be no failures recorded. However, if you run 100 requests, which is within the rate limit for a single account, there will be approximately 100 failures recorded with around 50 from each account.

Note that if you want to run this locally, the account id's and token have been omitted for security purposes and will need to be placed into the source code.

## Result with 50 Requests
```
Making 50 requests to each account
Your IP Address is X.X.X.X

No failures
```

## Result with 100 Requests
```
Making 100 requests to each account
Your IP Address is X.X.X.X

Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1152959 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Account #1398206 responded with TooManyRequests
Expected 0 failed requests, but found 100
```
