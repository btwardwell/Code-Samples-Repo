<?php

class Film {
    private string $title;
    private string $director;

    public function __construct(string $title, string $director) {
        $this->title = $title;
        $this->director = $director;
    }

    // PHP uses __clone() as the magic method (copy constructor) invoked when cloning an object
    public function __clone() {
        // Scalar values (like strings) are automatically copied by value in PHP cloning.
        // This method can be used to modify properties or perform deep copies of nested objects.
    }

    public function display(): void {
        echo "Title: " . $this->title . ", Director: " . $this->director . PHP_EOL;
    }
}

$film = new Film("Inception", "Christopher Nolan");
$film->display();

// Create a copy of the film object named filmCopy and display its data
$filmCopy = clone $film;
$filmCopy->display();

?>