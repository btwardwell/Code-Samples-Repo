<?php
// This example demonstrates the Single Responsibility Principle (SRP) in PHP.
interface Formatter {
    public function format(array $data): string;
}

// Each formatter class has a single responsibility: to format data in a specific way.
class CSVFormatter implements Formatter {
    public function format(array $data): string {
        $csv = '';
        foreach ($data as $key => $value) {
            $csv .= $key . ',' . $value . PHP_EOL;
        }
        return $csv;
    }
}

class JSONFormatter implements Formatter {
    public function format(array $data): string {
        return json_encode($data, JSON_PRETTY_PRINT);
    }
}

class HTMLFormatter implements Formatter {
    public function format(array $data): string {
        $html = "<table>\n";
        foreach ($data as $key => $value) {
            $html .= "  <tr><td>" . $key . "</td><td>" . $value . "</td></tr>\n";
        }
        $html .= "</table>";
        return $html;
    }
}

// The main function demonstrates how to use the different formatter classes.
function main(): void {
    $data = ["name" => "John Doe", "age" => "30"];

    $formatter = new CSVFormatter();
    echo $formatter->format($data) . PHP_EOL;

    $formatter = new JSONFormatter();
    echo $formatter->format($data) . PHP_EOL;

    $formatter = new HTMLFormatter();
    echo $formatter->format($data) . PHP_EOL;
}

main();