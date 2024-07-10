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

## Future Enhancements

---

- Logging: I plan to add functionality where the system logs the balls that have been called in the order they were called. This feature will be useful in case of a system failure or if someone questions the integrity of the game.

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
