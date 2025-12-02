# Chessboard3.0


To clone the project:

1. Go into the folder you want it
2. On the adressbar type "CMD"
3. In console paste:
   https://github.com/AlexanderJson/Chessboard3.0.git

Tools: 
Visual Studio for running the project


Instructions:
When starting the console app, type in the dimension of the board you want.


To create the board I decided to divide up responsibility in two parts, design and logic.

The logic part (Board.cs) holds all data about the board itself, and is responsible for creating a matrix of N rows and columns. To solve issue with plotting black/white tiles I decided to iterate the matrix with a nested for loop, so we iterate rows and then columns. In the inner loop we add (column + row) and use modulus to check whether the sum is even or not.
This returns a boolean matrix with 1 and 0 representing black and white.

This matrix is then used with the design part to actually write out the board on the console.

# Prompting

I used ChatGPT:
* to learn syntax regarding console design. Understanding how to make sounds, change colors etc. 
* to brainstorm how to correctly place out the tiles of the board. I had a general suspicion how I wanted to solve it, but using ChatGPT helped me with
  executing it correctly and also learning several different ways to solve this kind of problem. The solution I chose was to use modulus to check if the index in matrix was even/uneven. 


## Main prompts used for brainstorming:

### Prompt A:
  " Jag ska placera så varannan får svart och varannan vit! hur många lösningar finns? "
  ChatGPT gives out a list of potential solutions.

### Prompt B:
" ahaa! så om vi då skulle göra såhär? 1. vi börjar på första index i matris (col1,rad1) - vit, col2,rad1 - svart, col3+rad1 = 4 = jämn och därmed vit igen, col4+rad1 = 5 som är ojämn osv. funkar detta? "
ChatGPT confirms my approach and that I have understood the inital solution. 

### Discussion and solution AI helped me with

Then I have a long discussion how we "alert" when a index is even/uneven in the best way. ChatGPT then suggests using modulus. The majority of the discussion is me learning how it works, and me coming with my own ideas and suggestions in complement to the AI's suggestions. I initially wanted to "flip" each index between 0 and 1 for every iteration uisng "isEven = !isEven;". 

But AI helped me understand that this wouldn't work that well for a chessboard. In the end I chose to go with modulus after learning how it solved the issue. 
