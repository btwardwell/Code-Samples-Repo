<?php

abstract class Account {
    protected float $balance = 0.0;

    // In a real-world scenario, you might want to add more methods and properties here
    public function deposit(float $amount): void {
        if ($amount > 0) {
            $this->balance += $amount;
            echo "Deposited: $amount, New balance: $this->balance" . PHP_EOL;
        }
    }

    // Withdraw method is implemented in the base class, but can be overridden in subclasses if needed.
    public function withdraw(float $amount): void {
        if ($amount > 0 && $this->balance >= $amount) {
            $this->balance -= $amount;
            echo "Withdrawn: $amount, New balance: $this->balance" . PHP_EOL;
        } else {
            echo "Withdrawal failed. Insufficient balance." . PHP_EOL;
        }
    }

    public function getBalance(): float {
        return $this->balance;
    }
}

class CheckingAccount extends Account {
    // Inherits deposit() and withdraw() as-is — no overrides needed.
}

class SavingsAccount extends Account {
    // Inherits deposit() as-is.

    public function addInterest(): void {
        $interest = $this->balance * 0.05; // 5% interest
        $this->balance += $interest;
        echo "Interest added, New Balance: $this->balance" . PHP_EOL;
    }
}

class LoanAccount extends Account {
    // Inherits withdraw() as-is.

    public function repayLoan(float $amount): void {
        if ($amount > 0) {
            $this->balance += $amount;
            echo "Loan repayment, New Balance: $this->balance" . PHP_EOL;
        }
    }
}

function main(): void {
    $checkingAccount = new CheckingAccount();
    $checkingAccount->deposit(100);
    $checkingAccount->withdraw(50);

    $savingsAccount = new SavingsAccount();
    $savingsAccount->deposit(200);
    $savingsAccount->addInterest();

    $loanAccount = new LoanAccount();
    $loanAccount->withdraw(300);
    $loanAccount->repayLoan(100);
}

main();

// Example for proper condition over inheritance
// declare(strict_types=1); must be at the top of the file, before any other code or whitespace.

// A shared contract that any weapon must fulfill. This is what lets
// Character treat a Sword and a Bow interchangeably.
interface Weapon {
    public function use(): void;
}

class Sword implements Weapon {
    public function use(): void {
        echo "Swinging the sword!" . PHP_EOL;
    }
}

class Bow implements Weapon {
    public function use(): void {
        echo "Shooting an arrow!" . PHP_EOL;
    }
}

// Character no longer extends a weapon — it HAS a weapon, supplied
// via constructor injection, and delegates attack() to it.
class Character {
    public function __construct(private Weapon $weapon) {}

    public function attack(): void {
        $this->weapon->use();
    }

    // Composition's payoff: a character can swap weapons at runtime,
    // which inheritance could never allow.
    public function setWeapon(Weapon $weapon): void {
        $this->weapon = $weapon;
    }
}

function main(): void {
    $hero = new Character(new Sword());
    $hero->attack();

    $archer = new Character(new Bow());
    $archer->attack();

    // Swap the archer's weapon at runtime, just to prove the point.
    $archer->setWeapon(new Sword());
    $archer->attack();
}

main();