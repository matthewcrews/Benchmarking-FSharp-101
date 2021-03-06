# Benchmarking F# 101

This is some simple code I put together to illustrate how to do basic benchmarking with F#.

I was befuddled by the results of the different looping constructs (`for .. = .. to` versus `for .. in`). I expected one to be faster than the others and I got the opposite result. Since then I have looked at the assembly and can see that the resulting x86 is faster but I haven't figured out why yet. This is the goal of my next recording and post.

Assembly results are [here](https://sharplab.io/#v2:EYLgxg9gTgpgtADwGwBYA0AbEAzAzmgFxAEsMAfCABxgDsACAZQE9cCYBbAWACgrbGWbdgDoAwhAwYYYAsQg1cwgOK0YUYmB48CTanQBCtMAAt2AQygBrXHQAUASjoBeLdzru6UgnQAmZgmbiAK403k50AIwADFE8Hp4w3rhm7JRSwaHOkbFuHl6eEFQZYdkA+jE58flQZjQ+EAAi/mZZANpk7mQAunF5iXQ1dRDsAJJ1GjA24e3drvHsHMBqdKXCYz4wCABi0AAyhZR2ji658e757EEBwFJ0ZmBgWTm9Z3TY0HTET3QEEAO19VG4zAk2Eu1oAHMCMY6HBIr4/i9Xn1vINAetNlk0cN1hNcK1iD1Tsj3AB6UmMYYwOgQaHLADu0EsdGMahgwg5SJJ90eAB44Ty6ABqf5DJoBVrYoEbBBErkeHlzDwLdhLKArNZ1TY7KAAUXuxn2VCOznl536l2ut0F4WexPi73VX2I9CidA5ovRwNB4JoUJhcIiCLoZrO1QBOK1CCxEeleIJRJJ8XJlIWNLp6sZVhZbI5wlD8UF/LuD2FnsazUlsYxsqVr0V3CRKrVGp1+pMRsODlN9pRdEtZhu1JtdDtJMd5elmJdk9xIJs9QLHhTDCp6dZmaZOdgeaX7iLAtLIux4rMVaGU9rjd7+4eQA=) on SharbLab for those interested.
