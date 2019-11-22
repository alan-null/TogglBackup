# TogglBackup
**TogglBackup** is a console application that can be used to dump all Toggl entires into json on a disk

## Usage

### CLI parameters

| short name   |      long name      |  description |
|----------|-------------|:------|
| -a, | --api         | **Required.** API key for Toggl service.    |
| -s, | --startDate   | **Required.** Start date for crawler        |
| -e, | --endDate     | **Required.** End date for crawler          |
| -o, | --outputFile  | Name of the output file (default: out.json) |
|     | --help        | Display this help screen.                   |
|     | --version     | Display version information.                |

### Example invocation

```cmd
TogglBackup.exe --api bg9e607cb1eb1212e23c15b73c0cc423 -s "2019-1-1" -e "2020-1-1" -o dump.json
```