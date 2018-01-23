"""
2018-01-12
MAF
This is the script used to fetch wordlists from various sources online.
If ran directly, you may input sources as a commandline commandline parameter.
1st parameter is the source file name

sites have a list of links that contain lists of words for a the category

get all categories, combine them and add words into them
save as json
http://www.manythings.org/vocabulary/lists/c/
http://www.enchantedlearning.com/wordlist/

dictionary of categories which has a list of words

"""
#TODO: skip 404-sites or exclude them outright
#TODO: remove <li> tags

#TODO: exception handling

import time
import requests
import json
from bs4 import BeautifulSoup

#TODO: how to pick up only links that are 'sub'-links
"""
In this function we fetch the potential word categories from the sources.
"""
def getCategories(source,wait_time = 1):
    #common courtesy, sleep a bit
    time.sleep(wait_time)
    r = requests.get(source)
    print("getcat:"+str(r.status_code))
    soup = BeautifulSoup(r.text, 'html.parser')
    for link in soup.find_all('a'):
        #yield in a different format? maybe return multiple arguments?
        yield link

#TODO: if 404 or other error, exception
#TODO: return only the meat data, remove the soup-parts
def getWords(source,wait_time = 1):
    #either li-elements or contents of a table
    #Something
    time.sleep(wait_time)
    r = requests.get(source)
    #print("getword:"+str(r.status_code))
    if r.status_code != 200:
        return
    soup = BeautifulSoup(r.text, 'html.parser')
    #easy part
    if soup.find_all('li'):
        for word in soup.find_all('li'):
            # ?
            yield word.string
    #harder part - implement for other sources? table is the key here
    # 1st table with BORDER=1 seems to be the part where the data is stored
    else:
        print(soup.find(BORDER=1))
        return soup.find(BORDER=1)

def combineWordLists(sources, limit = -1, wait_time = 1):
    wordLists = dict()
    for source in sources:

        if limit == 0:
            break
        else:
            limit -= 1
        #used wait_time
        for category in getCategories(source, wait_time):
            if limit == 0:
                break
            else:
                limit -= 1
            if category.get_text() not in wordLists.keys():
                wordLists[category.get_text()] = []
                # print("new category")    
            #used wait_time
            #loop this
            for word in getWords(source+category.get('href'), wait_time):
                wordLists[category.get_text()].append(word)
            #wordLists[category.get_text()].append(list(getWords(source+category.get('href')), wait_time))    
            #for word in getWords(source)
    print(wordLists)
    #remove empty categories
    rm_list = []
    for cat in wordLists.keys():
        if len(wordLists[cat]) < 1:
            rm_list.append(cat)
    for cat in rm_list:
        wordLists.pop(cat, None)        
    return wordLists        

if __name__ == "__main__":       
    import sys, json
    try:
        #here is a list of sources for our little project
        #,"http://www.enchantedlearning.com/wordlist/"
        sources = ["http://www.manythings.org/vocabulary/lists/c/"]
        wait_time = 1
        if len(sys.argv) > 2:
            sources = sys.argv[2:]
        
        #Create a dumb ballpark for how long this process will last
        lenght_of_task = 0
        for source in sources:
            #obviously
            lenght_of_task += len(list(getCategories(source)))
        print("This task will take approx. " + str(lenght_of_task*wait_time) + " seconds to process")
        if len(sys.argv) > 1:
            with open(sys.argv[1],'w') as filer:
                json.dump(combineWordLists(sources), filer)
        else:
            print(combineWordLists(sources, limit = 4))  
    except Exception as e:
        raise Exception()
    finally:
        print()    