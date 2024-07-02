import { useParamsStore } from "@/hooks/useParamsStore"
import { Button } from "flowbite-react/components/Button"
import { AiOutlineClockCircle, AiOutlineSortAscending } from "react-icons/ai"
import { BsFillStopCircleFill } from "react-icons/bs"

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

export default function Filters() {
    const setParams = useParamsStore(state => state.setParams)
    const orderBy = useParamsStore(state => state.orderBy)

    return (
        <div className="flex justify-between items-center mb-4">
            <div>
                <span className="uppercase text-sm text-gray-500 mr-2">Order by</span>
                <Button.Group>
                    {orderButtons.map(({label, icon: Icon, value}) => (
                        <Button key={value}
                                onClick={() => setParams({orderBy: value})}
                                color={`${orderBy === value ? "red" : "gray"}`}>
                            
                            <Icon className="mr-3 h-4 w-4" /> 
                            {label}
                            
                        </Button>
                    ))}
                </Button.Group>
            </div>
        </div>
    )
}