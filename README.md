# cc-cut
Coding challenges cut tool

## Instructions

### -f
Field number. It can be a single value or a list of values. It indicates which field columns to work with. To run this command I used the following call `./CC-Cut-Tool -f1 sample.tsv` while being located in the right directory (in this case `bin\net8.0`). The `sample.tsv` file was also in that directory.

### -d
Specifies a delimiter character. It is the tab character (`'\t'1`) by default. Usage example: `./CC-Cut-Tool -f1 -d',' fourchords.csv`.
