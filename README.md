 CyberAware - Cybersecurity Awareness Chatbot

<div align="center">

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Windows](https://img.shields.io/badge/Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white)
![Version](https://img.shields.io/badge/version-1.0.0-blue?style=for-the-badge)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

An interactive command-line chatbot that educates users about cybersecurity threats and best practices

[Features](#features) • [Installation](#installation) • [Usage](#usage) • [Architecture](#architecture) • [Troubleshooting](#troubleshooting)

</div>



 Table of Contents

- [About The Project](#about-the-project)
- [Features](#features)
- [Project Structure](#project-structure)
- [Installation](#installation)
- [Configuration](#configuration)
- [Usage Guide](#usage-guide)
- [Audio Setup](#audio-setup)
- [Architecture Overview](#architecture-overview)
- [Code Documentation](#code-documentation)
- [CI/CD Pipeline](#cicd-pipeline)
- [Troubleshooting](#troubleshooting)
- [Contributing](#contributing)
- [License](#license)



 About The Project

CyberAware is a comprehensive cybersecurity awareness chatbot built with C# and .NET 8.0. The application runs in the Windows console and provides an interactive, educational experience about online security threats. It features voice greetings, typewriter-style text animation, color-coded responses, and intelligent keyword-based natural language processing.

 Target Audience
- General public seeking cybersecurity education
- South African users (localized threats like SIM swap scams)
- Students learning about secure online practices
- Organizations conducting security awareness training



 Features

 Core Functionality
| Feature | Description |
|---------|-------------|
|  Voice Greeting | Plays a welcome message on startup (supports WAV/M4A) |
|  Typewriter Effect | Natural, human-like text animation with configurable speed |
|  Rich Console UI | Color-coded messages (cyan for bot, green for user, etc.) |
|  Smart Responses | Keyword-based natural language processing with priority matching |
|  Localized Content | South Africa-specific threats (SIM swap, vishing, WhatsApp fraud) |
|  Input Validation | Name validation (2-30 chars, no numbers, auto-capitalization) |
|  Extensible Architecture | Easy to add new responses via dictionary |

 Cybersecurity Topics Covered
-  Password safety & best practices (12+ characters, password managers)
-  Phishing scams & email fraud detection
-  Safe browsing habits (HTTPS, padlock icon)
-  SIM swap scams (South Africa-specific)
-  Vishing (voice phishing)
-  Two-Factor Authentication (2FA)
-  Social engineering awareness
-  Banking security tips

 Commands
| Command | Action |
|---------|--------|
| `exit`, `quit`, `bye`, `goodbye` | End conversation |
| `help` | Display help menu |
| `how are you` | Greeting response |
| `who are you` | Bot identity |



 
