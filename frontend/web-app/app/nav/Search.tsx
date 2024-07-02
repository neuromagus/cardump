"use client"

import { useParamsStore } from "@/hooks/useParamsStore"
import { FaSearch } from "react-icons/fa"

export default function Search() {
    const setParams = useParamsStore(state => state.setParams)
    const setSearchValue = useParamsStore(state => state.setSearchValue)
    const searchValue = useParamsStore(state => state.searchValue)

    const onChange = (event: any) => {
        setSearchValue(event.target.value)
    }

    const search = () => {
        setParams({searchTerm: searchValue})
    }

    return (
        <div className="flex md:xl:w-[50%] m-3 md:xl:m-0 items-center border-2 
                        rounded-full py-2 shadow-smal">
            <input type="text"
                   onKeyDown={(e: any) => {
                       if(e.key === "Enter") search()
                   }}
                   value={searchValue}
                   onChange={onChange}
                   placeholder="Search for cars by make model or color"
                   className="flex-grow pl-5 bg-transparent focus:outline-none border-transparent
                              focus:border-transparent focus:ring-0 text-sm text-gray-600"
            />
            <button onClick={search}>
                <FaSearch size={35} className="bg-red-400 text-white rounded-full py-2
                                               cursor-pointer mr-2"/>
            </button>
        </div>
    )
}