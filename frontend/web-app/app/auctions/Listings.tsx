"use client"

import AuctionCard from "./AuctionCard"
import AppPagination from "../components/AppPagination"
import { useEffect, useState } from "react"
import { Auction, PageResult } from "@/types"
import { getData } from "../actions/auctionActions"
import { shallow } from "zustand/shallow"
import { useParamsStore } from "@/hooks/useParamsStore"
import qs from "query-string"
import Filters from "./Filters"
import EmptyFilter from "../components/EmptyFilter"
import { useAuctionStore } from "@/hooks/useAuctionStore"

export default function Listings()
{
    const [loading, setLoading] = useState(true)

    const params = useParamsStore( state => ({
        pageNumber: state.pageNumber,
        pageSize: state.pageSize,
        searchTerm: state.searchTerm,
        orderBy: state.orderBy,
        filterBy: state.filterBy,
        seller: state.seller,
        winner: state.winner
    }), shallow)

    const data = useAuctionStore( state => ({
        auctions: state.auctions,
        pageCount: state.pageCount,
        totalCount: state.totalCount
    }), shallow)

    const setData = useAuctionStore(state => state.setData)
    const setParams = useParamsStore(state => state.setParams)
    const url = qs.stringifyUrl({ url: "", query: params })

    function setPageNumber(pageNumber: number)
    {
        setParams({ pageNumber })
    }

    useEffect(() =>
    {
        getData(url).then(data =>
        {
            setData(data)
            setLoading(false)
        })
    }, [url])

    if (loading) return <h3>Loading...</h3>

    return (
        <>
            <Filters />
            {data.totalCount === 0 ? (
                <EmptyFilter showReset />
            ) : (
                <>
                    <div className="grid md:grid-cols-2 xl:grid-cols-4 gap-6 ">
                        {data.auctions.map(auction => (
                            <AuctionCard auction={auction} key={auction.id} />
                        ))}
                    </div>
                    <div className="flex justify-center mt-4">
                        <AppPagination pageChanged={setPageNumber} 
                                       currentPage={params.pageNumber}
                                       pageCount={data.pageCount} />
                    </div>
                </>
            )}
        </>
    )
}
