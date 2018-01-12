"""
2018-01-12
MAF
This is the script used to fetch wordlists from various sources online.
"""

import time
import requests
import json
from bs4 import BeautifulSoup

def callSite(source):
    r = requests.get(source)
    soup = BeautifulSoup(r.text, 'html.parser')
    print(soup.title)

callSite("http://www.manythings.org/vocabulary/lists/c/")