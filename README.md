# BrixExercise2 
FindAnagram


This project finds anagrams in a list of 5 characters long alphanumerical string.

The logic is based on comparing sorted strings with the use of a dictionary (hash-table).
When the app is started, the data is being intialized as a dictionary of sorded string and the matched anagrams in the file.

when a user type an input:
1. The input is being sorted and lowcased as the dictionary keys.
2. The anagrams (if exsits) are taken from the dictionary by the sorted string key.
