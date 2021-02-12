# Harvest Rate Limit Test

This repository contains a small console app that illustrating that the Harvest API appears to be rate limiting to 100 requests per 15 seconds per IP address, and not per account token. 

Documentation for Harvest Rate Limits is [here](git@github.com:rightteaminc/harvest-rate-limit-test.git).

## Test Process

1. Initialize 2 separate Harvest accounts (unique account id and token)
2. Make a rapid number of requests to each account
3. Record any responses that result in a failure

Observe that if the app is run with 50 requests, there should be no failures recorded. However, if you run 100 requests, which is within the rate limit for a single account, there will be approximately 100 failures recorded with around 50 from each account.
