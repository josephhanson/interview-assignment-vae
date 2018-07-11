# Interview Assignment

## Description ##

A bigram is any two adjacent words in the text. A histogram is the count of how many times that particular bigram occurred in the text. 

Create an application that can take as input any text file and output a histogram of the bigrams in the text. Given the text: “The quick brown fox and the quick blue hare.” The bigrams with their counts would be:

“the quick” 2  
“quick brown” 1  
“brown fox” 1  
“fox and” 1  
“and the” 1  
“quick blue” 1  
“blue hare” 1


 
## Directions ##
1. Clone the repo:  git clone http://github.com/josephhanson/interview-assignment-vae.git

2. Open the property sheet for the BigramConsoleApplication project > Debug > Command line arguments

3. Enter sample-text.txt into the dialog box

4. Press CTRL – F5


See BigramApi.IntegrationTests > BigramTests.cs for an overview of the program logic.

 

## Notes ##

Main goals were good abstractions, code readability, and future flexibility.  

Bigrams are composed of words, words are composed of characters.  These seem like good abstractions.  

The classes are small, easy to understand, easy to replace/refactor (current code behind the interfaces is first pass code - e.g. the character stream). 

It's flexible.  If your character source changes - AWS S3, Web API, etc., you drop in a new class.  If your user interface changes - e.g. Web, add a new project and reference the api and presentation layers (may need to refactor presentation layer - extract common functionality and reference from the two presentation layers).

### Misc ###

Didn't use a DI container or factories to configure startup classes so configuration changes to detail classes would not affect the use case class (program.cs).

Didn't use the Parser library because there is only one argument.  If there were more than one and/or numerous optional variables I would reconsider.

Would add more tests for production code.
 
Note: the extent of my console application experience is limited, and only with one-off utility programs. 
