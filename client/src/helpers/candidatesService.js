const candidatesService = {}

candidatesService.getAll = () => {
    return fetch('https://localhost:5001/candidate')
        .then( res => res.json())
        .then( res => res.data)
}

candidatesService.getById = (id) => {
  return fetch(`https://localhost:5001/candidate/${id}`)
      .then( res => res.json())
      .then( res => res.data)
}

candidatesService.create = (candidate) => {
    return fetch('https://localhost:5001/candidate', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(candidate)
      })
      .then( res => res.json())
      .then( res => res.data)
}

candidatesService.update = (candidate) => {
    return fetch('https://localhost:5001/candidate', {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(candidate)
      })
      .then( res => res.json())
      .then( res => res.data)
}

export default candidatesService
