$(() => {
	let x = 1;
	$("#add-row").on('click', function () {
		
		$("#input").append(`<div class="col-md-4">
								<input id="firstname${x}" type="text" class="form-control" name="people[${x}].firstname" placeholder="First Name" />
							</div>
							<div class="col-md-4">
								<input id="lastname${x}" type="text" class="form-control" name="people[${x}].lastname" placeholder="Last Name" />
							</div>
							<div class="col-md-4">
								<input id="age${x}" type="text" class="form-control" name="people[${x}].age" placeholder="Age" />
							</div>`)
		x++;
		$("#submit").prop('disabled', true);	
	})

	$("#whole-thing").on('input', 'input', function () {
		ensureFormValidity();
	}) 

	function ensureFormValidity() {

		for (let i = 0; i < x; i++) {
			const firstName = $(`#firstname${i}`).val();
			const lastName = $(`#lastname${i}`).val();
			const age = $(`#age${i}`).val();

			if (!firstName || !lastName || !age) {
				$("#submit").prop('disabled', true)
				return;
			}
		}
		$("#submit").prop('disabled', false);
	} 
})