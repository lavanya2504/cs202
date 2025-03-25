# **CS202: Software Tools and Techniques | Assessment 2**  

This repository contains code submissions for the second assessment of the **CS202: Software Tools and Techniques** course. It includes three folders, each containing scripts used for lab activities, along with generated files.

---

## **Lab 5**  
This folder contains:
- The **coverage report** generated after executing the provided test suite.
- Various **visualizations** created by parsing the coverage data.

---

## **Lab 6**  
This folder includes:
- A **Python script** that automates the execution of parallel tests under different configurations, running each configuration **three times** and recording the average execution time.
- **Text files** storing the recorded execution times for both sequential and parallel test runs, named accordingly.
- A **Python script** used to generate visualizations based on the collected test results.

---

## **Labs 7 & 8**  
This folder contains:
- **Three subfolders**, each holding Bandit security analysis reports for different repositories. These reports were generated using a **PowerShell script**, which is also included.
- A **PowerShell script** that automates the execution of Bandit to collect security analysis data from repositories.
- **Python scripts** for further analysis of the Bandit reports:
  - `analyze_bandit.py`: Reads Bandit reports within a repository folder and generates **timeline_data.json** and **cwe_counts.json** for that repository.
  - `generate_visualisations.py` & `cwe_graph_generation.py`: Create **graphs** to visualize security vulnerabilities and trends more effectively.

This repository provides all necessary scripts and reports for the assessment, ensuring a comprehensive analysis of software testing and security evaluation techniques.



