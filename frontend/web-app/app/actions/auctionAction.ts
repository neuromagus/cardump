"use server"

import { Auction, PageResult } from "@/types";

export async function getData(pageNumber: number = 1): Promise<PageResult<Auction>> {
    const num = 8 // show this number on page
    const res = await fetch(`http://localhost:6001/search?pageSize=${num}&pageNumber=${pageNumber}`)

    if (!res.ok) throw new Error("Failed to fetch data")
    
    return res.json();
}
