import { getDetailedViewData } from "@/app/actions/auctionActions"
import Heading from "@/app/components/Heading"
import CountdownTimer from "../../CountdownTimer"
import CarImage from "../../CarImage"
import DetailedSpecs from "./DetailedSpecs"
import { getCurrentUser } from "@/app/actions/authAction"
import EditButton from "./EditButton"
import DeleteButton from "./DeleteButton"
import BidList from "./BidList"

export default async function Details({params}: {params: {id:string}}) {
    const data = await getDetailedViewData(params.id)
    const user = await getCurrentUser()
    
    return (
        <div>
            <div className="flex flex-col md:flex-row md:justify-between">
                <div className="flex flex-col md:flex-row md:items-center gap-3">
                    <Heading title={`${data.make} ${data.model}`} />
                    {user?.username === data.seller && (
                        <div className="flex gap-2 mt-2 md:mt-0">
                            <EditButton id={data.id} />
                            <DeleteButton id={data.id} />
                        </div>
                    )}
                </div>
                
                <div className="flex flex-col md:flex-row gap-2 md:gap-3 mt-4 md:mt-0">
                    <h3 className="text-xl md:text-2xl font-semibold">Time remaining:</h3>
                    <CountdownTimer auctionEnd={data.auctionEnd} />
                </div>
            </div>
            
            <div className="grid grid-cols-1 md:xl:grid-cols-2 gap-6 mt-3">
                <div className="w-full bg-gray-200 aspect-h-10 
                    aspect-w-16 rounded-lg overflow-hidden">
                    <CarImage imageUrl={data.imageUrl} />
                </div>
                <BidList user={user} auction={data} />
            </div>

            <div className="mt-3 grid grid-cols-1 rounded-lg">
                <DetailedSpecs auction={data} />
            </div>
        </div>
    )
}