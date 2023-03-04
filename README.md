# RandomFileGenerator

The random file generator comes in two parts"

1. The Library
Use the library code to create your own tool, command line or windowed.  
You can fill in the options object from a windows form instead of using the command line partser

2. As a command line application
The project also builds a simple command line tool using standard syntax for arguments.

At this writing you can generate binary or text files.  Text files are generated as Lorem Ipsum


``` CSharp
Here is how you use the app:
Usage:
        -f, --file... name of file to generate

        -s, --size[optional]... Size of file in units

        -u, --unit[optional]... Units are Bytes, KBytes, MBytes, GByte (B|b, K|k, M|m, Gg)

        -t, --type[optional]... Text or Binary

        -p, --paragraphize[optional]...

        --min[optional]... Minimum Paragraph Size in words

        --max[optional]... Maximum Paragraph Size in words

Have fun!

```

