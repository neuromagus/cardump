"use server"

import { fetchWrapper } from "@/lib/fetchWrapper";
import { Auction, PageResult } from "@/types";
import { FieldValues } from "react-hook-form";

export async function getData(query: string): Promise<PageResult<Auction>> {    
    return await fetchWrapper.get(`search${query}`)
}

export async function createAuction(data: FieldValues) {
    return await fetchWrapper.post("auctions", data)
}

export async function getDetailedViewData(id: string): Promise<Auction> {
    return await fetchWrapper.get(`auctions/${id}`)
}