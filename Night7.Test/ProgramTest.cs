using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;

namespace Night7.Test
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void Verify_Build_Bag_Multiple()
        {
            List<string> input = new List<string>()
            {
              "striped",
              "white",
              "4",
              "drab",
              "silver",
              "3",
              "mirrored",
              "violet",
              "5",
              "bright",
              "gold",
            };

            Bag expected = new Bag()
            {
                Color = "striped white",
                Contents = new List<Bag>()
                {
                    {
                        new Bag()
                        {
                            Color = "drab silver",
                        }
                    },
                    {
                        new Bag()
                        {
                            Color = "mirrored violet",
                        }
                     },
                     {
                        new Bag()
                        {
                            Color = "bright gold",
                        }
                      },
                }
            };

            Program.BuildBag(input, new List<Bag>()).Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Verify_Build_Bag_Single()
        {
            List<string> input = new List<string>()
            {
              "striped",
              "white",
              "4",
              "drab",
              "silver"
            };

            Bag expected = new Bag()
            {
                Color = "striped white",
                Contents = new List<Bag>()
                {
                    new Bag()
                    {
                        Color = "drab silver"
                    }
                }
            };

            Program.BuildBag(input, new List<Bag>()).Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Verify_Build_Bag_None()
        {
            List<string> input = new List<string>()
            {
              "striped",
              "white"
            };

            Bag expected = new Bag()
            {
                Color = "striped white",
                Contents = new List<Bag>()
                { }
            };

            Program.BuildBag(input, new List<Bag>()).Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Verify_Parse_Input()
        {
            string[] input = new string[]
            {
              "muted lavender bags contain 1 pale gold bag.",
              "clear fuchsia bags contain 1 dull gray bag, 2 shiny indigo bags, 3 posh olive bags, 5 vibrant plum bags."
            };

            List<Bag> expected = new List<Bag>()
            {
                new Bag()
                {
                    Color = "muted lavender",
                    Contents = new List<Bag>()
                    {
                        new Bag()
                        {
                            Color = "pale gold",
                        },
                    }
                },
                new Bag()
                {
                    Color = "clear fuchsia",
                    Contents = new List<Bag>()
                    {
                        new Bag()
                        {
                            Color = "dull gray",
                        },
                        new Bag()
                        {
                            Color = "shiny indigo",
                        },
                        new Bag()
                        {
                            Color = "posh olive",
                        },
                        new Bag()
                        {
                            Color = "vibrant plum",
                        },
                    }
                }
            };

            Program.ParseInput(input).Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Verify_Add_Bag_Existing()
        {
            List<Bag> existingBags = new List<Bag>()
            {
                new Bag()
                { 
                    Color = "bright fushia",
                    Contents = new List<Bag>()
                    {
                        new Bag()
                        {
                            Color = "dark teal",
                        }
                    }
                }
            };

            Bag bag = new Bag()
            {
                Color = "deep purple"
            };

            string color = "bright fushia";

            List<Bag> expectedBags = new List<Bag>()
            {
                new Bag()
                {
                    Color = "bright fushia",
                    Contents = new List<Bag>()
                    {
                        new Bag()
                        {
                            Color = "dark teal",
                        }
                    }
                },
                new Bag()
                {
                    Color = "deep purple",
                    Contents = new List<Bag>
                    {
                        new Bag()
                        {
                            Color = "bright fushia",
                            Contents = new List<Bag>()
                            {
                                new Bag()
                                {
                                    Color = "dark teal",
                                }
                            }
                        },
                    }
                },
            };

            Program.AddToBagList(color, existingBags, bag);
            existingBags.Should().BeEquivalentTo(expectedBags);
        }

        [TestMethod]
        public void Verify_Recurse_Through_Bag_One_Level()
        {
            Bag input = new Bag()
            {
                Color = "hot pink",
                Contents = new List<Bag>()
                {
                    new Bag()
                    {
                        Color = "shiny gold"
                    },
                    new Bag()
                    {
                        Color = "deep teal",
                        Contents = new List<Bag>()
                        {
                            new Bag()
                            {
                                Color = "shiny gold"
                            }
                        }
                    },
                    new Bag()
                    {
                        Color = "dull gray"
                    }
                }
            };

            Program.RecurseThroughBag(input).Should().Be(true);
        }

        [TestMethod]
        public void Verify_Recurse_Through_Bag_Top_Level()
        {
            Bag input = new Bag()
            {
                Color = "shiny gold",
            };

            Program.RecurseThroughBag(input).Should().Be(false);
        }

        [TestMethod]
        public void Verify_Recurse_Through_Bag_Two_Levels()
        {
            Bag input = new Bag()
            {
                Color = "hot pink",
                Contents = new List<Bag>()
                {
                    new Bag()
                    {
                        Color = "apple green"
                    },
                    new Bag()
                    {
                        Color = "deep teal",
                        Contents = new List<Bag>()
                        {
                            new Bag()
                            {
                                Color = "shiny gold"
                            }
                        }
                    },
                    new Bag()
                    {
                        Color = "dull gray"
                    }
                }
            };

            Program.RecurseThroughBag(input).Should().Be(true);
        }

        [TestMethod]
        public void Verify_Build_Bag_Reference()
        {

            Bag input = new Bag()
            {
                Color = "hot pink",
                Contents = new List<Bag>()
                {
                    new Bag()
                    {
                        Color = "apple green"
                    },
                    new Bag()
                    {
                        Color = "deep teal",
                        Contents = new List<Bag>()
                        {
                            new Bag()
                            {
                                Color = "shiny gold"
                            }
                        }
                    },
                    new Bag()
                    {
                        Color = "dull gray"
                    }
                }
            };

            Program.RecurseThroughBag(input).Should().Be(true);
        }
    }
}
