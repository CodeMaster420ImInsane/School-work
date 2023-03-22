word = input("Choose a word to check if it is a palindrome \n")
if (word == word[::-1]):
    print(f"The word {word} is a palindrome")
else:
    print(f"The word {word} is not a palindrome")
