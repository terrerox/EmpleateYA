import React from 'react'

const CandidateInfo = ({selectedCandidate}) => {
    return (
        <div>
            <h3>{selectedCandidate.name}</h3>
            <h5>{selectedCandidate.salaryExpectation}</h5>
            <h5>{selectedCandidate.email}</h5>
        </div>
    )
}

export default CandidateInfo
