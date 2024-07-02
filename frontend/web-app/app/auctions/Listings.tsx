"use client"

import AuctionCard from "./AuctionCard"
import AppPagination from "../components/AppPagination"
import { useEffect, useState } from "react"
import { Auction, PageResult } from "@/types"
import { getData } from "../actions/auctionAction"
import { shallow } from "zustand/shallow"
import { useParamsStore } from "@/hooks/useParamsStore"
import qs from "query-string"
import Filters from "./Filters"

export default function Listings() {
    const [data, setData] = useState<PageResult<Auction>>()
    const params = useParamsStore(state => ({
        pageNumber: state.pageNumber,
        pageSize: state.pageSize,
        searchTerm: state.searchTerm,
        orderBy: state.orderBy
    }), shallow)

    const setParams = useParamsStore(state => state.setParams)
    const url = qs.stringifyUrl({url: "", query: params})

    function setPageNumber(pageNumber: number) {
        setParams({pageNumber})
    }

    useEffect(() => {
        getData(url).then(data => {
            setData(data)
        })
    }, [url])

    if (!data) return <h3>Loading...</h3>

    return (
        <>
            <Filters />
            <div className="grid grid-cols-4 gap-6">
                {data.results.map(auction => (
                    <AuctionCard auction={auction} key={auction.id} />
                ))}
            </div>
            <div className="flex justify-center mt-4">
                <AppPagination pageChanged={setPageNumber} currentPage={params.pageNumber}
                     pageCount={data.pageCount} />
            </div>
        </>
        
    )
}
