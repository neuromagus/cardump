"use client"

import { Button } from "flowbite-react/components/Button";
import Link from "next/link";

export default function UserActions() {
    return (
        <Button outline>
            <Link href="/session">
                Session
            </Link>
        </Button>
    )
}