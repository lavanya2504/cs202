import json
import os
import csv
from collections import Counter

# Path to the main folder containing all repository folders
main_folder = "C:/Users/Lavanya/Documents/STT/Lab7-8/results"

# CSV output file
output_csv = "bandit_analysis_results.csv"

# Open CSV file for writing
with open(output_csv, "w", newline="") as csvfile:
    fieldnames = ["Repository", "Commit Hash", "Severity_High", "Severity_Medium", "Severity_Low",
                  "Confidence_High", "Confidence_Medium", "Confidence_Low", "CWE_Counts"]
    
    writer = csv.DictWriter(csvfile, fieldnames=fieldnames)
    writer.writeheader()

    # Iterate through each repository folder inside the main folder
    for repo in os.listdir(main_folder):
        repo_path = os.path.join(main_folder, repo)
        
        if not os.path.isdir(repo_path):  # Skip non-folder files
            continue

        print(f"Processing repository: {repo}")

        # Iterate through all Bandit reports in this repository
        for filename in os.listdir(repo_path):
            if filename.endswith(".json"):
                commit_hash = filename.replace("bandit_report_", "").replace(".json", "")

                with open(os.path.join(repo_path, filename), "r") as f:
                    data = json.load(f)

                    high, medium, low = 0, 0, 0
                    high_conf, medium_conf, low_conf = 0, 0, 0
                    commit_cwe_counts = Counter()

                    for issue in data.get("results", []):
                        severity = issue["issue_severity"]
                        confidence = issue["issue_confidence"]
                        cwe = issue.get("issue_cwe", "Unknown CWE")

                        # Handle CWE field (if it's a dictionary)
                        if isinstance(cwe, dict):
                            cwe = cwe.get("id", "Unknown CWE")

                        # Track severity levels
                        if severity == "HIGH":
                            high += 1
                        elif severity == "MEDIUM":
                            medium += 1
                        elif severity == "LOW":
                            low += 1

                        # Track confidence levels
                        if confidence == "HIGH":
                            high_conf += 1
                        elif confidence == "MEDIUM":
                            medium_conf += 1
                        elif confidence == "LOW":
                            low_conf += 1

                        # Count CWEs
                        commit_cwe_counts[cwe] += 1

                    # Write to CSV
                    writer.writerow({
                        "Repository": repo,
                        "Commit Hash": commit_hash,
                        "Severity_High": high,
                        "Severity_Medium": medium,
                        "Severity_Low": low,
                        "Confidence_High": high_conf,
                        "Confidence_Medium": medium_conf,
                        "Confidence_Low": low_conf,
                        "CWE_Counts": json.dumps(dict(commit_cwe_counts))  # Store CWE counts as JSON string
                    })

print(f"\nData saved in '{output_csv}' for further analysis.")
