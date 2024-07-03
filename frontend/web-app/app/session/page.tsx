import { getSession } from "../actions/authAction"
import Heading from "../components/Heading"

export default async function Session() {
    const session = await getSession()

    return (
        <>
            <Heading title="Session dashboard" />
            <div className="bg-blue-200 border-2 border-blue-500">
                <h3 className="text-lg">Session data</h3>
                <pre>{JSON.stringify(session, null, 2)}</pre>
            </div>
        </>
    )
}