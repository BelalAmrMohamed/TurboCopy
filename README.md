# TurboCopy

A high-performance file copying utility designed for speed and efficiency.

## Table of Contents

- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Configuration](#configuration)
- [Examples](#examples)
- [Contributing](#contributing)
- [License](#license)
- [Support](#support)

## Features

- **Lightning-Fast Performance**: Optimized algorithms for rapid file transfers
- **Batch Operations**: Copy multiple files simultaneously with ease
- **Progress Tracking**: Real-time progress indicators and transfer statistics
- **Error Handling**: Robust error handling and recovery mechanisms
- **Cross-Platform**: Works seamlessly on Windows, macOS, and Linux
- **Flexible Filtering**: Filter files by type, size, date, and custom patterns
- **Resume Capability**: Resume interrupted transfers without re-copying
- **Verbose Logging**: Detailed logs for troubleshooting and auditing
- **Memory Efficient**: Low memory footprint even with large file transfers
- **CLI Interface**: Simple and intuitive command-line interface

## Installation

### Prerequisites

- Node.js 14.0 or higher
- npm 6.0 or higher

### From npm

```bash
npm install -g turbocopy
```

### From Source

```bash
# Clone the repository
git clone https://github.com/BelalAmrMohamed/TurboCopy.git
cd TurboCopy

# Install dependencies
npm install

# Link globally (optional)
npm link
```

## Usage

### Basic Syntax

```bash
turbocopy <source> <destination> [options]
```

### Required Arguments

- `<source>`: Path to the file or directory to copy
- `<destination>`: Path where files will be copied to

### Common Options

```bash
-r, --recursive        Copy directories recursively
-v, --verbose          Enable verbose output
-p, --parallel <n>     Number of parallel transfers (default: 4)
-f, --force            Overwrite existing files without confirmation
-s, --skip-existing    Skip files that already exist
--progress             Show progress bar
--dry-run              Show what would be copied without copying
--help                 Display help information
--version              Show version number
```

### Examples

#### Copy a single file
```bash
turbocopy ./source.txt ./destination.txt
```

#### Copy a directory recursively
```bash
turbocopy ./source-dir ./dest-dir -r
```

#### Copy with parallel transfers and progress tracking
```bash
turbocopy ./large-folder ./backup -r -p 8 --progress
```

#### Dry run to preview changes
```bash
turbocopy ./source ./dest -r --dry-run
```

#### Copy with verbose logging
```bash
turbocopy ./source ./dest -r -v
```

#### Skip existing files
```bash
turbocopy ./source ./dest -r --skip-existing
```

#### Force overwrite with parallel transfers
```bash
turbocopy ./source ./dest -r -f -p 6
```

## Configuration

### Configuration File

You can create a `.turbocopyrc` file in your project root:

```json
{
  "defaultParallel": 4,
  "defaultVerbose": false,
  "showProgress": true,
  "retryAttempts": 3,
  "retryDelay": 1000,
  "maxFileSize": null,
  "excludePatterns": [
    "node_modules/**",
    ".git/**",
    ".DS_Store",
    "*.tmp"
  ]
}
```

### Environment Variables

```bash
TURBOCOPY_PARALLEL=8
TURBOCOPY_VERBOSE=true
TURBOCOPY_DRY_RUN=false
```

## Examples

### Backup Project Directory
```bash
turbocopy ./my-project ./backups/my-project-$(date +%Y%m%d) -r --progress
```

### Sync Development Files
```bash
turbocopy ./src ./dist -r -p 8 --skip-existing
```

### Copy Large Media Files with Retry
```bash
turbocopy ./videos ./archive -r --progress -v
```

### Mirror Directory Structure
```bash
turbocopy ./source-tree ./destination-tree -r -f --verbose
```

## Contributing

We welcome contributions from the community! Here's how you can help:

### Getting Started

1. **Fork the repository** on GitHub
2. **Clone your fork** locally:
   ```bash
   git clone https://github.com/YOUR-USERNAME/TurboCopy.git
   cd TurboCopy
   ```
3. **Create a feature branch**:
   ```bash
   git checkout -b feature/your-feature-name
   ```

### Development Setup

```bash
# Install dependencies
npm install

# Run tests
npm test

# Run linter
npm run lint

# Build the project
npm run build
```

### Code Guidelines

- Follow the existing code style (ESLint configuration is provided)
- Write meaningful commit messages
- Add tests for new features
- Update documentation for significant changes
- Ensure all tests pass before submitting a PR

### Pull Request Process

1. **Update your fork** with the latest changes from upstream:
   ```bash
   git fetch upstream
   git rebase upstream/main
   ```

2. **Commit your changes** with clear, descriptive messages:
   ```bash
   git commit -m "Add: description of what you added"
   git commit -m "Fix: description of what you fixed"
   git commit -m "Docs: description of documentation changes"
   ```

3. **Push to your fork**:
   ```bash
   git push origin feature/your-feature-name
   ```

4. **Create a Pull Request**:
   - Go to the original repository and click "New Pull Request"
   - Select your fork and branch
   - Provide a clear description of your changes
   - Reference any related issues using `#issue-number`

5. **Address Review Feedback**:
   - Respond to any comments or requested changes
   - Make additional commits if needed
   - Ensure CI checks pass

### Commit Message Convention

- `feat:` A new feature
- `fix:` A bug fix
- `docs:` Documentation only changes
- `style:` Changes that don't affect code meaning (formatting, missing semicolons, etc.)
- `refactor:` Code change that neither fixes a bug nor adds a feature
- `perf:` Code change that improves performance
- `test:` Adding missing tests or correcting existing tests

### Reporting Issues

- Use GitHub Issues to report bugs
- Provide a clear title and description
- Include steps to reproduce the issue
- Mention your environment (OS, Node.js version, etc.)
- Attach error logs or screenshots if applicable

### Feature Requests

- Check existing issues to avoid duplicates
- Clearly describe the requested feature
- Explain the use case and benefits
- Propose possible implementation approaches

## Code of Conduct

- Be respectful and inclusive
- Provide constructive feedback
- Respect different opinions and approaches
- Report inappropriate behavior to maintainers

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Support

### Getting Help

- **Documentation**: Check the [docs](./docs) directory
- **Issues**: Search existing issues or create a new one
- **Discussions**: Use GitHub Discussions for questions and ideas
- **Email**: Contact the maintainers at [insert email]

### Troubleshooting

#### Common Issues

**Issue**: "Permission denied" errors
- **Solution**: Ensure you have read/write permissions for the source and destination directories

**Issue**: Out of memory errors with large files
- **Solution**: Reduce the number of parallel transfers using `-p 2` or `-p 1`

**Issue**: Slow transfer speeds
- **Solution**: Increase parallel transfers with `-p 8` or higher, depending on your system

**Issue**: Files not being copied
- **Solution**: Use `--verbose` or `--dry-run` to diagnose the issue

### Performance Tips

- Use appropriate parallel transfer settings based on your system resources
- For network transfers, test different parallel settings to find optimal speed
- Consider file system limitations when copying many small files
- Use `--skip-existing` when resuming interrupted transfers

## Changelog

See [CHANGELOG.md](CHANGELOG.md) for version history and release notes.

## Acknowledgments

Thank you to all contributors who have helped make TurboCopy better!

---

**Made with ❤️ by BelalAmrMohamed**