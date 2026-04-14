# CyberAware SA - Cybersecurity Awareness Chatbot

**Author:** Sipho Swartbooi  
**Module:** PROG6221 - Programming 2A  
**Assessment:** POE Part 1  
**Date:** April 2026

---

## Project Description

A command-line cybersecurity awareness chatbot for South African citizens. The bot educates users on online safety topics including:

- Phishing scams
- Safe password practices
- Recognising suspicious links
- General online safety

---

## Features Implemented

- Voice greeting on startup (WAV audio)
- ASCII art logo display
- Personalised text greeting using user's name
- Response system for cybersecurity questions
- Input validation with helpful error messages
- Memory feature (remembers user interests)
- Sentiment detection (responds to worried/curious/frustrated users)
- Coloured console UI with borders and spacing

---

## Setup Instructions

### Prerequisites

- Windows OS
- Visual Studio (2019 or 2022)
- .NET Framework (version specified by module)

### Steps to Run

1. Clone this repository: https://github.com/sipho-ctrl/CyberAware-SA-Chatbot.git


2. Open the solution file `CyberAwareSA.sln` in Visual Studio

3. Ensure the WAV audio file `Greeting.wav` is in the project folder (already included)

4. Press `F5` or click **Debug → Start Debugging** to run the program

---

## GitHub Actions CI Status

![CI Workflow](https://github.com/sipho-ctrl/CyberAware-SA-Chatbot/actions/workflows/dotnet.yml/badge.svg)

The workflow automatically builds the project on every commit to verify there are no compilation errors.

---

## Video Presentation

[Watch the CyberAware SA Chatbot Presentation](https://youtu.be/f82LNazzFyI)

*The video includes a full demonstration of the running application and a detailed code walkthrough.*

---

## Commit History

This repository contains 6+ meaningful commits as required:

1. Initial commit: Project setup
2. Added ASCII art and text greeting
3. Implemented basic response system
4. Added input validation
5. Implemented memory and sentiment features
6. Added enhanced console UI
7. Set up GitHub Actions CI

---

## Marking Criteria Coverage

| Criteria | Status |
|----------|--------|
| Correct submission with README | ✅ |
| GitHub & CI setup | ✅ |
| Voice greeting & ASCII art | ✅ |
| Greeting & user interaction | ✅ |
| Basic response system | ✅ |
| Input validation | ✅ |
| Enhanced console UI | ✅ |
| Code structure | ✅ |
| Video presentation | ✅ |

---

## Technologies Used

- C# .NET Console Application
- System.Media for voice greeting playback
- GitHub Actions for Continuous Integration
- ASCII art for visual branding

---

## Author

Sipho Swartbooi  
PROG6221 - Programming 2A  
IIE (The Independent Institute of Education)
