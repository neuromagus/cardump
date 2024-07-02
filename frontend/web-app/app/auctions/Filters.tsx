import { useParamsStore } from "@/hooks/useParamsStore"
import { Button } from "flowbite-react/components/Button"
import { AiOutlineClockCircle, AiOutlineSortAscending } from "react-icons/ai"
import { BsFillStopCircleFill, BsStopwatchFill } from "react-icons/bs"
import { GiFinishLine, GiFlame } from "react-icons/gi"

const orderButtons = [
    {
        label: "Alphabetical",
        icon: AiOutlineSortAscending,
        value: "make"
    },
    {
        label: "End date",
        icon: AiOutlineClockCircle,
        value: "endingSoon"
    },
    {
        label: "Recently added",
        icon: BsFillStopCircleFill,
        value: "new"
    },
]

const filterButtons = [
    {
        label: "Live Auctions",
        icon: GiFlame,
        value: "live"
    },
    {
        label: "Ending < 6 hours",
        icon: GiFinishLine,
        value: "endingSoon"
    },
    {
        label: "Completed",
        icon: BsStopwatchFill,
        value: "finished"
    },
]


export default function Filters() {
    const setParams = useParamsStore(state => state.setParams)
    const orderBy = useParamsStore(state => state.orderBy)
    const filterBy = useParamsStore(state => state.filterBy)

    return (
        <div className="md:xl:flex justify-between items-center mb-4">
            <div>
                <span className="uppercase text-sm text-gray-500 mr-2">Filter by</span>
                <Button.Group>
                    {filterButtons.map(({label, icon: Icon, value}) => (
                        <Button key={value}
                                onClick={() => setParams({filterBy: value})}
                                color={`${filterBy === value ? "red" : "gray"}`}>
                            
                            <Icon className="mr-3 md:xl:h-4 md:xl:w-4 h-6 w-6" /> 
                            <div className="hidden md:xl:block">
                                {label}
                            </div>
                        </Button>
                    ))}
                </Button.Group>
            </div>
            <div>
                <span className="uppercase text-sm text-gray-500 mr-2">Order by</span>
                <Button.Group>
                    {orderButtons.map(({label, icon: Icon, value}) => (
                        <Button key={value}
                                onClick={() => setParams({orderBy: value})}
                                color={`${orderBy === value ? "red" : "gray"}`}>
                            
                            <Icon className="mr-3 md:xl:h-4 md:xl:w-4 h-6 w-6" /> 
                            <div className="hidden md:xl:block">
                                {label}
                            </div>
                        </Button>
                    ))}
                </Button.Group>
            </div>
        </div>
    )
}