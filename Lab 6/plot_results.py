import matplotlib.pyplot as plt
import numpy as np

# Define a pastel color palette
pastel_colors = ['#A8D5BA',  # pastel green
                 '#F6D6AD',  # pastel orange
                 '#B5EAEA',  # pastel blue
                 '#F7CAC9',  # pastel pink
                 '#C1C8E4',  # pastel lavender
                 '#D3E4CD',  # pastel mint
                 '#E6E2AF',  # pastel yellow
                 '#E3D4B9']  # pastel beige

# Optionally set the color cycle for the current axes
plt.rcParams['axes.prop_cycle'] = plt.cycler(color=pastel_colors)

# Configurations and their average parallel execution times (in seconds)
configs = [
    "-n 1, threads 1, dist load",
    "-n 1, threads 1, dist no",
    "-n 1, threads auto, dist load",
    "-n 1, threads auto, dist no",
    "-n auto, threads 1, dist load",
    "-n auto, threads 1, dist no",
    "-n auto, threads auto, dist load",
    "-n auto, threads auto, dist no"
]

# Average parallel execution times (Tpar) for each configuration
Tpar = np.array([
    33.70,
    32.27,
    130.50,
    133.90,
    52.18,
    53.74,
    113.08,
    112.79
])

# Sequential execution time (Tseq)
Tseq = 25.87  # seconds

# Calculate speedup ratios: Tseq/Tpar
speedup = Tseq / Tpar

# Plot 1: Execution Times Comparison using pastel colors
plt.figure(figsize=(10,6))
x = np.arange(len(configs))
width = 0.35
plt.bar(x - width/2, [Tseq]*len(configs), width, color='#B0C4DE', label='Sequential (Tseq)')  # pastel light steel blue
plt.bar(x + width/2, Tpar, width, color='#FFDAB9', label='Parallel (Tpar)')  # pastel peach puff
plt.xticks(x, configs, rotation=45, ha='right')
plt.ylabel('Execution Time (seconds)')
plt.title('Sequential vs. Parallel Execution Times')
plt.legend()
plt.tight_layout()
plt.savefig('execution_times.png', dpi=300)
plt.show()

# Plot 2: Speedup Ratios using pastel colors
plt.figure(figsize=(10,6))
plt.bar(x, speedup, color=pastel_colors)
plt.xticks(x, configs, rotation=45, ha='right')
plt.ylabel('Speedup Ratio (Tseq/Tpar)')
plt.title('Speedup Ratios for Different Parallelization Configurations')
plt.tight_layout()
plt.savefig('speedup_ratios.png', dpi=300)
plt.show()
