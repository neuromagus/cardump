"use client"

import { useParamsStore } from "@/hooks/useParamsStore";
import { AiOutlineCar } from "react-icons/ai";

export default function Logo() {
    const reset = useParamsStore(state => state.reset)

    return (
        <div className="flex items-center gap-2 text-3xl font-semibold text-red-500 cursor-pointer"
             onClick={reset}
             title="reset search and filter">
        <AiOutlineCar size={34} />
        <div>
            Cardump auctions
        </div>
    </div>
   
    )
}