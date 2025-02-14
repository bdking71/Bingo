# Bingo

---

I originally developed a Bingo program in 2013 for the PTA at my daughter's elementary school. At the time, they were using a cheap store-bought case and cardboard cards to hold the balls. As is common with these games, the balls often ended up rolling around the floor, causing the caller to search for them after they were dropped.

I wanted a system similar to what larger Bingo halls have, featuring a way to see which balls have been called, the last ball called, the next ball to be called, and information about the current games being played.

The program I wrote in 2013 was designed in Visual Basic .NET (2010). This version is an update to the 2013 program and has been completely rewritten in Visual Studio C#.

## Screen Shots

---

![Main Screen](/img/main.png)
Main Screen

---

![Winning Patterns Alphabet Screen](/img/WinningPatternsAlphabet.png)
Alphabet Winning Patterns

---

![Winning Patterns General Screen](/img/WinningPatternsGeneral.png)
General Winning Patterns

---

![Winning Patterns Miscellaneous Screen](/img/WinningPatternsMiscellaneous.png)
Miscellaneous Winning Patterns

---

![Winning Patterns Specials Screen](/img/WinningPatternsSpecials.png)
Special Winning Patterns

## Features

---

- Although it's not required, this game is designed to be used with a large TV or projector, allowing players to see everything the caller is doing.
- A Board that displays the called balls and highlights the most recently called ball.
- All numbers from a row can be removed by clicking on the row header on the board before the game starts.
- Individual balls can be removed from the hopper by clicking on the ball number on the board before the game starts.
- A "Winning Patterns" control that displays the current game pattern. New patterns can be added via a JSON file.
- The "Winning Patterns" control supports multiple patterns.
- A built-in timer with 10, 15, 25, and 35-second intervals.
- A built-in "Caller" that can audibly announce the balls.
- The application keeps a file that represents the state of the game in case of a crash, and if the file exists when starting a new game, it will prompt you to load the last incomplete game.
- The state file become a log of the game after the game has been closed.

## Future Enhancements

---

- I plan to add a calculator into the right click menu which can help divide up the winnings. For example, if you're playing candy bar bingo, I envision a place to add the number of prize candy bars and the number of bingos, and the calculator would split the prize amount the winners.
- I would like to find a database of pre-printed cards that Amazon sells, and add in a feature to show the winning card on the screen.

## Legal Disclaimer

---

This Bingo program is provided for entertainment and educational purposes only. The use of this software must comply with all applicable state and federal laws regarding Bingo games. It is the responsibility of the user to ensure that their use of this program adheres to the relevant legal requirements in their jurisdiction.

By using this software, you acknowledge that you have reviewed the laws applicable to Bingo games in your area and agree to abide by them. The developers of this program are not responsible for any illegal use of the software.

## License

---

This software is open source and is licensed under the GNU General Public License version 3. You can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see https://www.gnu.org/licenses/gpl-3.0.en.html.

##Legal

This app uses the G7 Segment 7 S5 located at the following URL: https://www.dafont.com/g7-segment7-s5.font?l[]=10&l[]=1. Please find the .ttf file in the application directory and double click the font to install. The application will work without this font, and will use a default font if this isn't installed.

## How to Build

This application was developed using [Visual Studio 2022 Community Edition](https://visualstudio.microsoft.com/vs/community/). Upon opening the application for the first time, it is essential to click "Build" to compile the app and all associated user controls. This step must be completed before any code modifications to eliminate any user control errors that Visual Studio may display.
