namespace RussianPeasants
{
    using System;

    using Machine.Fakes;
    using Machine.Specifications;

    public abstract class WithPeasant : WithSubject<Peasant>
    {

    }

    public class when_told_to_multiply_eighteen_by_twenty_three : WithPeasant
    {
        private static PeasantResults result;

        private Because of = () => result = Subject.Multiply(18, 23);

        private It should_have_the_correct_amount_of_growths = () => result.Growths.Count.ShouldEqual(5);

        private It should_have_the_correct_amount_of_additions = () => result.Additions.Count.ShouldEqual(2);

        private It should_return_four_hundred_and_fourteen = () => result.Result.ShouldEqual(414);
    }

    public class when_given_random_numbers : WithPeasant
    {
        private It should_get_it_right_lots_of_times = () =>
        {
            var loop = 0;

            var random = new Random();

            while (loop < 40000)
            {
                int left = random.Next(1, 40000);
                int right = random.Next(1, 40000);

                Subject.Multiply(left, right).Result.ShouldEqual(left * right);
                Console.WriteLine("{0} * {1} = {2}", left, right, left * right);
                loop++;
            }
        };
    }
}
