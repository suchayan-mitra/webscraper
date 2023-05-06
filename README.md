---

# Web Scraper - C# Console Application

This repository contains a simple web scraper written in C# as a console application. The scraper fetches the content of a given website, parses the HTML, and writes the inner text of each leaf node to a text file. This project utilizes the [HtmlAgilityPack](https://github.com/zzzprojects/html-agility-pack) library for parsing HTML content.

## Features

- User input for website URL and output folder path
- Downloads and parses the content of the specified website
- Writes the parsed content as a text file in the provided output folder

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 5.0 or later)

## Installation

1. Clone the repository to your local machine:

   ```bash
   git clone https://github.com/your_username/web-scraper.git
   cd web-scraper
   ```

2. Install the required packages:

   ```bash
   dotnet restore
   ```

## Usage

1. Build and run the application:

   ```bash
   dotnet run
   ```

2. When prompted, enter the URL of the website you want to scrape (e.g., "https://example.com") and the output folder path where you want to save the text files (e.g., "C:\output").

3. The program will fetch the content of the specified website and save it as a text file in the provided output folder. The text file will be named using the host and the path of the URL (e.g., "example-com.txt").

## License

This project is licensed under the [MIT License](LICENSE).

---
